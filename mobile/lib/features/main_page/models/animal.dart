import 'package:json_annotation/json_annotation.dart';

part 'animal.g.dart';

@JsonSerializable(createToJson: false)
class Animal {
  const Animal({
    required this.imageUrl,
    required this.location,
  });

  // TODO: Replace with final field names
  @JsonKey(name: 'thumbnailUrl')
  final String imageUrl;
  @JsonKey(name: 'title')
  final String location;

  factory Animal.fromJson(Map<String, dynamic> json) => _$AnimalFromJson(json);
}
