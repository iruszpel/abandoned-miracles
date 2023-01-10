import 'dart:typed_data';

import 'package:flutter/material.dart';

class ReportResultPage extends StatelessWidget {
  const ReportResultPage({
    super.key,
    required this.imageData,
    required this.address,
    required this.longitude,
    required this.latitude,
    required this.detectedAnimal,
  });

  final Uint8List imageData;
  final String address;
  final String longitude;
  final String latitude;
  final String detectedAnimal;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Wynik zgłoszenia')),
      body: Padding(
        padding: const EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            Text(
              'Twoje zgłoszenie zostało przyjęte',
              style: Theme.of(context).textTheme.headline6,
            ),
            const SizedBox(height: 16),
            AspectRatio(
              aspectRatio: 1,
              child: Image.memory(
                imageData,
                fit: BoxFit.cover,
              ),
            ),
            const SizedBox(width: 16),
            TextFormField(
              initialValue: address,
              decoration: const InputDecoration(labelText: 'Adres'),
              enabled: false,
            ),
            const SizedBox(width: 16),
            Row(
              children: [
                Expanded(
                  child: TextFormField(
                    initialValue: longitude,
                    decoration: const InputDecoration(
                      labelText: 'Długość geograficzna',
                    ),
                    enabled: false,
                  ),
                ),
                const SizedBox(width: 16),
                Expanded(
                  child: TextFormField(
                    initialValue: latitude,
                    decoration: const InputDecoration(
                      labelText: 'Szerokość geograficzna',
                    ),
                    enabled: false,
                  ),
                ),
              ],
            ),
            const SizedBox(height: 16),
            ElevatedButton(
              onPressed: Navigator.of(context).pop,
              child: const Text('Wróć do strony głównej'),
            ),
          ],
        ),
      ),
    );
  }
}

class ReportResultPageRoute extends MaterialPageRoute<void> {
  ReportResultPageRoute({
    required Uint8List imageData,
    required String address,
    required String longitude,
    required String latitude,
    required String detectedAnimal,
  }) : super(
          builder: (context) => ReportResultPage(
            imageData: imageData,
            address: address,
            longitude: longitude,
            latitude: latitude,
            detectedAnimal: detectedAnimal,
          ),
        );
}
