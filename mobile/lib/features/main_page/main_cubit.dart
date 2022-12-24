import 'dart:convert';

import 'package:abandoned_miracles/features/main_page/models/animal.dart';
import 'package:bloc/bloc.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:http/http.dart';

part 'main_cubit.freezed.dart';

class MainCubit extends Cubit<MainState> {
  MainCubit(this._client) : super(const MainState.loading());

  final Client _client;

  Future<void> fetch() async {
    final result = await _client
        .get(Uri.parse('https://jsonplaceholder.typicode.com/photos'));

    if (result.statusCode != 200) {
      emit(const MainState.error());
      return;
    }

    emit(
      MainState.ready(
        (json.decode(result.body) as List<dynamic>)
            .map((itemData) => Animal.fromJson(itemData))
            .toList(),
      ),
    );
  }
}

@freezed
class MainState with _$MainState {
  const factory MainState.loading() = _Loading;

  const factory MainState.ready(List<Animal> animals) = _Ready;

  const factory MainState.error() = _Error;
}
