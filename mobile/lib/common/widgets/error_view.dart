import 'package:flutter/material.dart';

class ErrorView extends StatelessWidget {
  const ErrorView({
    super.key,
    required this.onRetry,
  });

  final VoidCallback onRetry;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        const Text('Coś poszło nie tak :('),
        const SizedBox(height: 16),
        TextButton(
          onPressed: onRetry,
          child: const Text('Spróbuj ponownie'),
        ),
      ],
    );
  }
}
