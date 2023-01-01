import 'dart:convert';

import 'package:abandoned_miracles/common/dtos/report_request.dart';
import 'package:abandoned_miracles/common/dtos/report_result.dart';
import 'package:azure_application_insights/azure_application_insights.dart';
import 'package:bloc/bloc.dart';
import 'package:flutter/foundation.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:http/http.dart';

part 'report_cubit.freezed.dart';

class ReportCubit extends Cubit<ReportState> {
  ReportCubit(
    this._client,
    this._telemetryClient,
  ) : super(const ReportState.idle());

  final Client _client;
  final TelemetryClient _telemetryClient;

  Future<void> onAddressAdded(String address) async {
    final state = this.state;

    if (state is! _Idle) {
      return;
    }

    final result = await _client.get(
      headers: {
        'subscription-key': 'yCs5uKGkVgHdjHzJb0exsp7iWdArBRdHpA3KsFmJcpM',
      },
      Uri.parse(
          'https://atlas.microsoft.com/search/address/json?api-version=1.0&query=$address'),
    );

    final position = json.decode(result.body)['results'][0]['position'];
    final lat = position['lat'];
    final lon = position['lon'];

    emit(
      state.copyWith(
        address: address,
        latitude: lat.toString(),
        longitude: lon.toString(),
      ),
    );
  }

  void onImageAdded(Uint8List imageData) {
    final state = this.state;

    if (state is! _Idle) {
      return;
    }

    emit(state.copyWith(imageData: imageData));
  }

  Future<void> onSubmit() async {
    final state = this.state;

    if (state is! _Idle) {
      return;
    }

    emit(state.copyWith(submitStatus: SubmitStatus.loading));

    try {
      final response = await _client.post(
        Uri.parse('https://todo/report'),
        body: json.encode(
          ReportRequest(
            imageData: base64.encode(state.imageData!),
            address: state.address,
            longitude: state.longitude,
            latitude: state.latitude,
          ),
        ),
      );

      if (response.statusCode == 200) {
        final result = ReportResult.fromJson(json.decode(response.body));

        emit(
          ReportState.success(
            imageData: state.imageData!,
            address: state.address,
            longitude: state.longitude,
            latitude: state.latitude,
            detectedAnimal: result.detectedAnimal,
          ),
        );
      } else {
        _telemetryClient.trackError(
          severity: Severity.error,
          error: 'Failed to submit report',
        );

        emit(state.copyWith(submitStatus: SubmitStatus.error));
      }
    } catch (e, st) {
      _telemetryClient.trackError(
        severity: Severity.error,
        error: e,
        stackTrace: st,
      );

      emit(state.copyWith(submitStatus: SubmitStatus.error));
    }
  }
}

enum SubmitStatus {
  idle,
  loading,
  error,
}

@freezed
class ReportState with _$ReportState {
  const factory ReportState.idle({
    Uint8List? imageData,
    @Default('') String address,
    @Default('') String longitude,
    @Default('') String latitude,
    @Default(SubmitStatus.idle) SubmitStatus submitStatus,
  }) = _Idle;

  const factory ReportState.success({
    required Uint8List imageData,
    required String address,
    required String longitude,
    required String latitude,
    required String detectedAnimal,
  }) = _Success;

  const ReportState._();

  bool get isFormValid =>
      imageData != null &&
      address.isNotEmpty &&
      longitude.isNotEmpty &&
      latitude.isNotEmpty;
}
