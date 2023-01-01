import 'package:abandoned_miracles/features/main_page/main_cubit.dart';
import 'package:abandoned_miracles/features/main_page/main_page.dart';
import 'package:azure_application_insights/azure_application_insights.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:http/http.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(const App());
}

class App extends StatelessWidget {
  const App({super.key});

  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        Provider(create: (context) => Client()),
        Provider(
          create: (context) => TransmissionProcessor(
            instrumentationKey: '8a4877e9-90ed-4695-abf0-1c5ec9c403e7',
            httpClient: context.read(),
            timeout: const Duration(seconds: 10),
          ),
        ),
        Provider(
            create: (context) => TelemetryClient(
                processor: context.read<TransmissionProcessor>())),
      ],
      child: MaterialApp(
        title: 'Abandoned miracles',
        home: BlocProvider(
          create: (context) => MainCubit(context.read())..fetch(),
          child: const MainPage(),
        ),
      ),
    );
  }
}
