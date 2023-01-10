import 'package:json_annotation/json_annotation.dart';

part 'report_request.g.dart';

@JsonSerializable(createFactory: false)
class ReportRequest {
  const ReportRequest({
    required this.base64Image,
    required this.description,
    required this.address,
    required this.longitude,
    required this.latitude,
  });

  final String base64Image;
  final String description;
  final String address;
  final String longitude;
  final String latitude;

  Map<String, dynamic> toJson() => _$ReportRequestToJson(this);
}
