import 'package:abandoned_miracles/features/main_page/main_cubit.dart';
import 'package:abandoned_miracles/features/main_page/main_page.dart';
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
    return MaterialApp(
      title: 'Abandoned miracles',
      home: MultiProvider(
        providers: [
          Provider(create: (context) => Client()),
          BlocProvider(create: (context) => MainCubit(context.read())..fetch()),
        ],
        child: const MainPage(),
      ),
    );
  }
}
