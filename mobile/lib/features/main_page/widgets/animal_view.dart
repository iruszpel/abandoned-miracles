import 'package:abandoned_miracles/features/main_page/models/animal.dart';
import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/widgets.dart';

class AnimalView extends StatelessWidget {
  const AnimalView({
    super.key,
    required this.animal,
  });

  final Animal animal;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(16),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: [
          CachedNetworkImage(
            height: 300,
            fit: BoxFit.cover,
            imageUrl: animal.imageUrl,
          ),
          const SizedBox(height: 16),
          Text(
            animal.location,
            overflow: TextOverflow.ellipsis,
          ),
        ],
      ),
    );
  }
}
