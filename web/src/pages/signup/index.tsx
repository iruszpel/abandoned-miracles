import React, { FunctionComponent } from "react";
import { Button, Form, Input, message } from "antd";
import Title from "antd/lib/typography/Title";
import { useMutation } from "@tanstack/react-query";
import loginManager from "../../utils/auth/loginManager";
import { useNavigate } from "react-router-dom";
import axios from "axios";

type SingUpDto = { email: string; password: string; confirmPassword: string };

const SignUpPage: FunctionComponent = () => {
  const navigate = useNavigate();

  const signUpMutation = useMutation({
    mutationFn: (user: SingUpDto) => {
      return axios.post(`/User/register`, user);
    },
    onSuccess: (data) => {
      // console.log(data);
      if (loginManager.handleSignUpResponse(data)) navigate("/signin");
    },
  });

  const onSignUp = async (user: {
    email: string;
    password: string;
    confirmPassword: string;
  }) => {
    if (user.password !== user.confirmPassword) {
      message.error("Hasła nie są takie same");
    }

    signUpMutation.mutate({
      email: user.email,
      password: user.password,
      confirmPassword: user.confirmPassword,
    });
  };

  return (
    <Form size="large" onFinish={onSignUp}>
      <Title>Zarejestruj się</Title>
      <Form.Item
        label="Email"
        labelCol={{ span: 24 }}
        name="email"
        rules={[
          {
            required: true,
            message: "Email is required",
          },
        ]}
      >
        <Input />
      </Form.Item>
      <Form.Item
        label="Hasło"
        labelCol={{ span: 24 }}
        name="password"
        rules={[
          {
            required: true,
            message: "Password is required",
          },
        ]}
      >
        <Input.Password />
      </Form.Item>
      <Form.Item
        label="Powtórz Hasło"
        labelCol={{ span: 24 }}
        name="confirmPassword"
        rules={[
          {
            required: true,
            message: "Password is required",
          },
        ]}
      >
        <Input.Password />
      </Form.Item>
      <Button htmlType="submit" type="primary">
        Zarejestruj się
      </Button>
    </Form>
  );
};

export default SignUpPage;
