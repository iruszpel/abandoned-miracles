import 'package:abandoned_miracles/features/auth_page/auth_cubit.dart';
import 'package:flutter/material.dart';

import 'package:flutter_bloc/flutter_bloc.dart';

class AuthPage extends StatefulWidget {
  const AuthPage({super.key});

  @override
  State<AuthPage> createState() => _AuthPageState();
}

class _AuthPageState extends State<AuthPage> {
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    final state = context.watch<AuthCubit>().state;

    if (state == AuthState.loading) {
      return const Scaffold(body: Center(child: CircularProgressIndicator()));
    }

    return Scaffold(
      body: SafeArea(
        child: Padding(
          padding: const EdgeInsets.all(16),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              TextFormField(
                decoration: const InputDecoration(labelText: 'Email'),
                controller: _emailController,
              ),
              const SizedBox(height: 16),
              TextFormField(
                decoration: const InputDecoration(labelText: 'Hasło'),
                controller: _passwordController,
              ),
              const SizedBox(height: 16),
              ElevatedButton(
                onPressed: () => context
                    .read<AuthCubit>()
                    .logIn(_emailController.text, _passwordController.text),
                child: const Text('Zaloguj się'),
              ),
              ElevatedButton(
                onPressed: () => context
                    .read<AuthCubit>()
                    .signUp(_emailController.text, _passwordController.text),
                child: const Text('Zarejestruj się'),
              ),
              if (state == AuthState.error)
                const Padding(
                  padding: EdgeInsets.symmetric(vertical: 16),
                  child: Text('Coś poszło nie tak'),
                ),
            ],
          ),
        ),
      ),
    );
  }
}
