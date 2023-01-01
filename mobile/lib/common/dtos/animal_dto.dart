import 'package:json_annotation/json_annotation.dart';

part 'animal_dto.g.dart';

@JsonSerializable(createToJson: false)
class AnimalDTO {
  const AnimalDTO({
    required this.imageUrl,
    required this.location,
  });

  // TODO: Replace with final field names
  @JsonKey(name: 'thumbnailUrl')
  final String imageUrl;
  @JsonKey(name: 'title')
  final String location;

  factory AnimalDTO.fromJson(Map<String, dynamic> json) =>
      _$AnimalDTOFromJson(json);
}
