import 'package:json_annotation/json_annotation.dart';

part 'report_result.g.dart';

@JsonSerializable(createToJson: false)
class ReportResult {
  const ReportResult({required this.animalType});

  final String animalType;

  factory ReportResult.fromJson(Map<String, dynamic> json) =>
      _$ReportResultFromJson(json);
}
