import 'package:abandoned_miracles/common/widgets/error_view.dart';
import 'package:abandoned_miracles/common/widgets/loading_view.dart';
import 'package:abandoned_miracles/features/main_page/main_cubit.dart';
import 'package:abandoned_miracles/features/main_page/widgets/report_view.dart';
import 'package:abandoned_miracles/features/report_page/report_page.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class MainPage extends StatelessWidget {
  const MainPage({
    super.key,
    required this.token,
  });

  final String token;

  @override
  Widget build(BuildContext context) {
    final state = context.watch<MainCubit>().state;

    return Scaffold(
      floatingActionButton: FloatingActionButton(
        onPressed: () => Navigator.of(context).push(ReportPageRoute(token)),
        child: const Icon(Icons.add),
      ),
      body: state.map(
        loading: (_) => const LoadingView(),
        ready: (state) => RefreshIndicator(
          onRefresh: context.watch<MainCubit>().fetch,
          child: ListView.separated(
            itemCount: state.reports.length,
            itemBuilder: (context, index) => ReportView(
              report: state.reports[index],
            ),
            separatorBuilder: (context, index) => const Divider(height: 1),
          ),
        ),
        error: (_) => ErrorView(onRetry: context.watch<MainCubit>().fetch),
      ),
    );
  }
}

class MainPageRoute extends MaterialPageRoute {
  MainPageRoute(String token)
      : super(
          builder: (context) => BlocProvider(
            create: (context) => MainCubit(
              token,
              context.read(),
            )..fetch(),
            child: MainPage(token: token),
          ),
        );
}
