import 'dart:convert';

import 'package:abandoned_miracles/features/main_page/main_page.dart';
import 'package:bloc/bloc.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class AuthCubit extends Cubit<AuthState> {
  AuthCubit(this._client, this._navigator) : super(AuthState.idle);

  final Client _client;
  final NavigatorState _navigator;

  Future<void> signUp(String email, String password) async {
    emit(AuthState.loading);

    final result = await _client.post(
      Uri.parse(
          'https://abandonedmiraclebackend.azurewebsites.net/user/register'),
      headers: {
        'Content-Type': 'application/json',
      },
      body: json.encode({
        'email': email,
        'password': password,
        'confirmPassword': password,
      }),
    );

    if (result.statusCode == 200) {
      final jsonResult = json.decode(result.body);

      _navigator.pushReplacement(MainPageRoute(jsonResult['token']));
      return;
    }

    emit(AuthState.error);
  }

  Future<void> logIn(String email, String password) async {
    emit(AuthState.loading);

    final result = await _client.post(
      Uri.parse('https://abandonedmiraclebackend.azurewebsites.net/user/login'),
      headers: {
        'Content-Type': 'application/json',
      },
      body: json.encode({
        'email': email,
        'password': password,
      }),
    );

    if (result.statusCode == 200) {
      final jsonResult = json.decode(result.body);

      _navigator.pushReplacement(MainPageRoute(jsonResult['token']));
      return;
    }

    emit(AuthState.error);
  }
}

enum AuthState {
  idle,
  loading,
  error,
}
