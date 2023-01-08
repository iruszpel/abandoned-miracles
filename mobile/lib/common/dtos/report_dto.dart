import 'package:json_annotation/json_annotation.dart';

part 'report_dto.g.dart';

@JsonSerializable(createToJson: false)
class ReportDTO {
  const ReportDTO({
    required this.imageUrl,
    required this.address,
    required this.status,
  });

  final String imageUrl;
  final String address;
  final String status;

  bool get isOpen => status == 'Open';

  factory ReportDTO.fromJson(Map<String, dynamic> json) =>
      _$ReportDTOFromJson(json);
}
