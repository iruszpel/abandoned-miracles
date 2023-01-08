import 'dart:convert';

import 'package:abandoned_miracles/common/dtos/report_dto.dart';
import 'package:bloc/bloc.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:http/http.dart';

part 'main_cubit.freezed.dart';

class MainCubit extends Cubit<MainState> {
  MainCubit(this._token, this._client) : super(const MainState.loading());

  final String _token;
  final Client _client;

  Future<void> fetch() async {
    final result = await _client.get(
      Uri.parse(
          'https://abandonedmiraclebackend.azurewebsites.net/client/my-reports'),
      headers: {'Authorization': 'Bearer $_token'},
    );

    if (result.statusCode != 200) {
      emit(const MainState.error());
      return;
    }

    emit(
      MainState.ready(
        (json.decode(result.body) as List<dynamic>)
            .map((itemData) => ReportDTO.fromJson(itemData))
            .toList(),
      ),
    );
  }
}

@freezed
class MainState with _$MainState {
  const factory MainState.loading() = _Loading;

  const factory MainState.ready(List<ReportDTO> reports) = _Ready;

  const factory MainState.error() = _Error;
}
