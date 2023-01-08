import 'package:abandoned_miracles/common/dtos/report_dto.dart';
import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/widgets.dart';

class ReportView extends StatelessWidget {
  const ReportView({
    super.key,
    required this.report,
  });

  final ReportDTO report;

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
            imageUrl: report.imageUrl,
          ),
          const SizedBox(height: 16),
          Text(
            report.isOpen ? 'Otwarte' : 'Zamknięte',
            overflow: TextOverflow.ellipsis,
          ),
        ],
      ),
    );
  }
}
