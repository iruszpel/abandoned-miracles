// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'report_cubit.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

/// @nodoc
mixin _$ReportState {
  Uint8List? get imageData => throw _privateConstructorUsedError;
  String get address => throw _privateConstructorUsedError;
  String get longitude => throw _privateConstructorUsedError;
  String get latitude => throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function(Uint8List? imageData, String address,
            String longitude, String latitude, SubmitStatus submitStatus)
        idle,
    required TResult Function(Uint8List imageData, String address,
            String longitude, String latitude, String detectedAnimal)
        success,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function(Uint8List? imageData, String address, String longitude,
            String latitude, SubmitStatus submitStatus)?
        idle,
    TResult? Function(Uint8List imageData, String address, String longitude,
            String latitude, String detectedAnimal)?
        success,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function(Uint8List? imageData, String address, String longitude,
            String latitude, SubmitStatus submitStatus)?
        idle,
    TResult Function(Uint8List imageData, String address, String longitude,
            String latitude, String detectedAnimal)?
        success,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_Idle value) idle,
    required TResult Function(_Success value) success,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_Idle value)? idle,
    TResult? Function(_Success value)? success,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_Idle value)? idle,
    TResult Function(_Success value)? success,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;

  @JsonKey(ignore: true)
  $ReportStateCopyWith<ReportState> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $ReportStateCopyWith<$Res> {
  factory $ReportStateCopyWith(
          ReportState value, $Res Function(ReportState) then) =
      _$ReportStateCopyWithImpl<$Res, ReportState>;
  @useResult
  $Res call(
      {Uint8List imageData, String address, String longitude, String latitude});
}

/// @nodoc
class _$ReportStateCopyWithImpl<$Res, $Val extends ReportState>
    implements $ReportStateCopyWith<$Res> {
  _$ReportStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? imageData = null,
    Object? address = null,
    Object? longitude = null,
    Object? latitude = null,
  }) {
    return _then(_value.copyWith(
      imageData: null == imageData
          ? _value.imageData!
          : imageData // ignore: cast_nullable_to_non_nullable
              as Uint8List,
      address: null == address
          ? _value.address
          : address // ignore: cast_nullable_to_non_nullable
              as String,
      longitude: null == longitude
          ? _value.longitude
          : longitude // ignore: cast_nullable_to_non_nullable
              as String,
      latitude: null == latitude
          ? _value.latitude
          : latitude // ignore: cast_nullable_to_non_nullable
              as String,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$_IdleCopyWith<$Res> implements $ReportStateCopyWith<$Res> {
  factory _$$_IdleCopyWith(_$_Idle value, $Res Function(_$_Idle) then) =
      __$$_IdleCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {Uint8List? imageData,
      String address,
      String longitude,
      String latitude,
      SubmitStatus submitStatus});
}

/// @nodoc
class __$$_IdleCopyWithImpl<$Res>
    extends _$ReportStateCopyWithImpl<$Res, _$_Idle>
    implements _$$_IdleCopyWith<$Res> {
  __$$_IdleCopyWithImpl(_$_Idle _value, $Res Function(_$_Idle) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? imageData = freezed,
    Object? address = null,
    Object? longitude = null,
    Object? latitude = null,
    Object? submitStatus = null,
  }) {
    return _then(_$_Idle(
      imageData: freezed == imageData
          ? _value.imageData
          : imageData // ignore: cast_nullable_to_non_nullable
              as Uint8List?,
      address: null == address
          ? _value.address
          : address // ignore: cast_nullable_to_non_nullable
              as String,
      longitude: null == longitude
          ? _value.longitude
          : longitude // ignore: cast_nullable_to_non_nullable
              as String,
      latitude: null == latitude
          ? _value.latitude
          : latitude // ignore: cast_nullable_to_non_nullable
              as String,
      submitStatus: null == submitStatus
          ? _value.submitStatus
          : submitStatus // ignore: cast_nullable_to_non_nullable
              as SubmitStatus,
    ));
  }
}

/// @nodoc

class _$_Idle extends _Idle with DiagnosticableTreeMixin {
  const _$_Idle(
      {this.imageData,
      this.address = '',
      this.longitude = '',
      this.latitude = '',
      this.submitStatus = SubmitStatus.idle})
      : super._();

  @override
  final Uint8List? imageData;
  @override
  @JsonKey()
  final String address;
  @override
  @JsonKey()
  final String longitude;
  @override
  @JsonKey()
  final String latitude;
  @override
  @JsonKey()
  final SubmitStatus submitStatus;

  @override
  String toString({DiagnosticLevel minLevel = DiagnosticLevel.info}) {
    return 'ReportState.idle(imageData: $imageData, address: $address, longitude: $longitude, latitude: $latitude, submitStatus: $submitStatus)';
  }

  @override
  void debugFillProperties(DiagnosticPropertiesBuilder properties) {
    super.debugFillProperties(properties);
    properties
      ..add(DiagnosticsProperty('type', 'ReportState.idle'))
      ..add(DiagnosticsProperty('imageData', imageData))
      ..add(DiagnosticsProperty('address', address))
      ..add(DiagnosticsProperty('longitude', longitude))
      ..add(DiagnosticsProperty('latitude', latitude))
      ..add(DiagnosticsProperty('submitStatus', submitStatus));
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$_Idle &&
            const DeepCollectionEquality().equals(other.imageData, imageData) &&
            (identical(other.address, address) || other.address == address) &&
            (identical(other.longitude, longitude) ||
                other.longitude == longitude) &&
            (identical(other.latitude, latitude) ||
                other.latitude == latitude) &&
            (identical(other.submitStatus, submitStatus) ||
                other.submitStatus == submitStatus));
  }

  @override
  int get hashCode => Object.hash(
      runtimeType,
      const DeepCollectionEquality().hash(imageData),
      address,
      longitude,
      latitude,
      submitStatus);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$_IdleCopyWith<_$_Idle> get copyWith =>
      __$$_IdleCopyWithImpl<_$_Idle>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function(Uint8List? imageData, String address,
            String longitude, String latitude, SubmitStatus submitStatus)
        idle,
    required TResult Function(Uint8List imageData, String address,
            String longitude, String latitude, String detectedAnimal)
        success,
  }) {
    return idle(imageData, address, longitude, latitude, submitStatus);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function(Uint8List? imageData, String address, String longitude,
            String latitude, SubmitStatus submitStatus)?
        idle,
    TResult? Function(Uint8List imageData, String address, String longitude,
            String latitude, String detectedAnimal)?
        success,
  }) {
    return idle?.call(imageData, address, longitude, latitude, submitStatus);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function(Uint8List? imageData, String address, String longitude,
            String latitude, SubmitStatus submitStatus)?
        idle,
    TResult Function(Uint8List imageData, String address, String longitude,
            String latitude, String detectedAnimal)?
        success,
    required TResult orElse(),
  }) {
    if (idle != null) {
      return idle(imageData, address, longitude, latitude, submitStatus);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_Idle value) idle,
    required TResult Function(_Success value) success,
  }) {
    return idle(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_Idle value)? idle,
    TResult? Function(_Success value)? success,
  }) {
    return idle?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_Idle value)? idle,
    TResult Function(_Success value)? success,
    required TResult orElse(),
  }) {
    if (idle != null) {
      return idle(this);
    }
    return orElse();
  }
}

abstract class _Idle extends ReportState {
  const factory _Idle(
      {final Uint8List? imageData,
      final String address,
      final String longitude,
      final String latitude,
      final SubmitStatus submitStatus}) = _$_Idle;
  const _Idle._() : super._();

  @override
  Uint8List? get imageData;
  @override
  String get address;
  @override
  String get longitude;
  @override
  String get latitude;
  SubmitStatus get submitStatus;
  @override
  @JsonKey(ignore: true)
  _$$_IdleCopyWith<_$_Idle> get copyWith => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class _$$_SuccessCopyWith<$Res> implements $ReportStateCopyWith<$Res> {
  factory _$$_SuccessCopyWith(
          _$_Success value, $Res Function(_$_Success) then) =
      __$$_SuccessCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {Uint8List imageData,
      String address,
      String longitude,
      String latitude,
      String detectedAnimal});
}

/// @nodoc
class __$$_SuccessCopyWithImpl<$Res>
    extends _$ReportStateCopyWithImpl<$Res, _$_Success>
    implements _$$_SuccessCopyWith<$Res> {
  __$$_SuccessCopyWithImpl(_$_Success _value, $Res Function(_$_Success) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? imageData = null,
    Object? address = null,
    Object? longitude = null,
    Object? latitude = null,
    Object? detectedAnimal = null,
  }) {
    return _then(_$_Success(
      imageData: null == imageData
          ? _value.imageData
          : imageData // ignore: cast_nullable_to_non_nullable
              as Uint8List,
      address: null == address
          ? _value.address
          : address // ignore: cast_nullable_to_non_nullable
              as String,
      longitude: null == longitude
          ? _value.longitude
          : longitude // ignore: cast_nullable_to_non_nullable
              as String,
      latitude: null == latitude
          ? _value.latitude
          : latitude // ignore: cast_nullable_to_non_nullable
              as String,
      detectedAnimal: null == detectedAnimal
          ? _value.detectedAnimal
          : detectedAnimal // ignore: cast_nullable_to_non_nullable
              as String,
    ));
  }
}

/// @nodoc

class _$_Success extends _Success with DiagnosticableTreeMixin {
  const _$_Success(
      {required this.imageData,
      required this.address,
      required this.longitude,
      required this.latitude,
      required this.detectedAnimal})
      : super._();

  @override
  final Uint8List imageData;
  @override
  final String address;
  @override
  final String longitude;
  @override
  final String latitude;
  @override
  final String detectedAnimal;

  @override
  String toString({DiagnosticLevel minLevel = DiagnosticLevel.info}) {
    return 'ReportState.success(imageData: $imageData, address: $address, longitude: $longitude, latitude: $latitude, detectedAnimal: $detectedAnimal)';
  }

  @override
  void debugFillProperties(DiagnosticPropertiesBuilder properties) {
    super.debugFillProperties(properties);
    properties
      ..add(DiagnosticsProperty('type', 'ReportState.success'))
      ..add(DiagnosticsProperty('imageData', imageData))
      ..add(DiagnosticsProperty('address', address))
      ..add(DiagnosticsProperty('longitude', longitude))
      ..add(DiagnosticsProperty('latitude', latitude))
      ..add(DiagnosticsProperty('detectedAnimal', detectedAnimal));
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$_Success &&
            const DeepCollectionEquality().equals(other.imageData, imageData) &&
            (identical(other.address, address) || other.address == address) &&
            (identical(other.longitude, longitude) ||
                other.longitude == longitude) &&
            (identical(other.latitude, latitude) ||
                other.latitude == latitude) &&
            (identical(other.detectedAnimal, detectedAnimal) ||
                other.detectedAnimal == detectedAnimal));
  }

  @override
  int get hashCode => Object.hash(
      runtimeType,
      const DeepCollectionEquality().hash(imageData),
      address,
      longitude,
      latitude,
      detectedAnimal);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$_SuccessCopyWith<_$_Success> get copyWith =>
      __$$_SuccessCopyWithImpl<_$_Success>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function(Uint8List? imageData, String address,
            String longitude, String latitude, SubmitStatus submitStatus)
        idle,
    required TResult Function(Uint8List imageData, String address,
            String longitude, String latitude, String detectedAnimal)
        success,
  }) {
    return success(imageData, address, longitude, latitude, detectedAnimal);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function(Uint8List? imageData, String address, String longitude,
            String latitude, SubmitStatus submitStatus)?
        idle,
    TResult? Function(Uint8List imageData, String address, String longitude,
            String latitude, String detectedAnimal)?
        success,
  }) {
    return success?.call(
        imageData, address, longitude, latitude, detectedAnimal);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function(Uint8List? imageData, String address, String longitude,
            String latitude, SubmitStatus submitStatus)?
        idle,
    TResult Function(Uint8List imageData, String address, String longitude,
            String latitude, String detectedAnimal)?
        success,
    required TResult orElse(),
  }) {
    if (success != null) {
      return success(imageData, address, longitude, latitude, detectedAnimal);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_Idle value) idle,
    required TResult Function(_Success value) success,
  }) {
    return success(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_Idle value)? idle,
    TResult? Function(_Success value)? success,
  }) {
    return success?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_Idle value)? idle,
    TResult Function(_Success value)? success,
    required TResult orElse(),
  }) {
    if (success != null) {
      return success(this);
    }
    return orElse();
  }
}

abstract class _Success extends ReportState {
  const factory _Success(
      {required final Uint8List imageData,
      required final String address,
      required final String longitude,
      required final String latitude,
      required final String detectedAnimal}) = _$_Success;
  const _Success._() : super._();

  @override
  Uint8List get imageData;
  @override
  String get address;
  @override
  String get longitude;
  @override
  String get latitude;
  String get detectedAnimal;
  @override
  @JsonKey(ignore: true)
  _$$_SuccessCopyWith<_$_Success> get copyWith =>
      throw _privateConstructorUsedError;
}
