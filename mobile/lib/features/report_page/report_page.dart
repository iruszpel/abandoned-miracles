// ignore_for_file: use_build_context_synchronously

import 'package:abandoned_miracles/features/report_page/report_cubit.dart';
import 'package:abandoned_miracles/features/report_result_page/report_result_page.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:image_picker/image_picker.dart';

class ReportPage extends StatelessWidget {
  const ReportPage({super.key});

  @override
  Widget build(BuildContext context) {
    final state = context.watch<ReportCubit>().state;

    return BlocListener<ReportCubit, ReportState>(
      listener: (context, state) {
        state.mapOrNull(success: (state) {
          Navigator.of(context).pushReplacement(
            ReportResultPageRoute(
              imageData: state.imageData,
              address: state.address,
              longitude: state.longitude,
              latitude: state.latitude,
              detectedAnimal: state.detectedAnimal,
            ),
          );
        });
      },
      child: Scaffold(
        appBar: AppBar(title: const Text('Zgłoś zwierzę')),
        body: SingleChildScrollView(
          child: state.map(
            idle: (state) {
              if (state.submitStatus == SubmitStatus.loading) {
                return const Center(
                    child: Center(child: CircularProgressIndicator()));
              }

              return Padding(
                padding: const EdgeInsets.all(16),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.stretch,
                  children: [
                    state.imageData != null
                        ? Image.memory(
                            state.imageData!,
                            height: 300,
                            fit: BoxFit.cover,
                          )
                        : InkWell(
                            onTap: () => _onAddImage(context),
                            child: Container(
                              height: 300,
                              decoration: BoxDecoration(
                                border: Border.all(color: Colors.grey),
                              ),
                              alignment: Alignment.center,
                              child: const Text('Dodaj zdjęcie'),
                            ),
                          ),
                    const SizedBox(width: 16),
                    TextFormField(
                      key: ValueKey(state.address),
                      initialValue: state.address,
                      decoration: const InputDecoration(labelText: 'Adres'),
                      onFieldSubmitted:
                          context.watch<ReportCubit>().onAddressAdded,
                    ),
                    const SizedBox(width: 16),
                    Row(
                      children: [
                        Expanded(
                          child: TextFormField(
                            key: ValueKey(state.longitude),
                            initialValue: state.longitude,
                            decoration: const InputDecoration(
                              labelText: 'Długość geograficzna',
                            ),
                          ),
                        ),
                        const SizedBox(width: 16),
                        Expanded(
                          child: TextFormField(
                            key: ValueKey(state.latitude),
                            initialValue: state.latitude,
                            decoration: const InputDecoration(
                              labelText: 'Szerokość geograficzna',
                            ),
                          ),
                        ),
                      ],
                    ),
                    const SizedBox(height: 16),
                    ElevatedButton(
                      onPressed: state.isFormValid
                          ? context.watch<ReportCubit>().onSubmit
                          : null,
                      child: const Text('Zgłoś'),
                    ),
                    if (state.submitStatus == SubmitStatus.error)
                      const Padding(
                        padding: EdgeInsets.symmetric(vertical: 16),
                        child: Text('Coś poszło nie tak'),
                      ),
                  ],
                ),
              );
            },
            success: (_) =>
                const Center(child: Center(child: CircularProgressIndicator())),
          ),
        ),
      ),
    );
  }

  Future<void> _onAddImage(BuildContext context) async {
    final file = await ImagePicker().pickImage(source: ImageSource.camera);

    if (file == null) {
      return;
    }

    final imageData = await file.readAsBytes();

    context.read<ReportCubit>().onImageAdded(imageData);
  }
}

class ReportPageRoute extends MaterialPageRoute {
  ReportPageRoute()
      : super(
          builder: (context) => BlocProvider(
            create: (context) => ReportCubit(
              context.read(),
              context.read(),
            ),
            child: const ReportPage(),
          ),
        );
}
