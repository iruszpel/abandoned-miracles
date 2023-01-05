import React, { FunctionComponent } from "react";
import { Button, Form, Input, message } from "antd";
import Title from "antd/lib/typography/Title";
import loginManager from "../../utils/auth/loginManager";
import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router";
import axios from "axios";

type SingInDto = { email: string; password: string };

export type SignInResponse = {
  token: string;
  email: string;
};

const SignInPage: FunctionComponent = () => {
  const navigate = useNavigate();

  const signInMutation = useMutation({
    mutationFn: (user: SingInDto) => {
      return axios.post<SignInResponse>(`/User/login`, user);
    },
    onSuccess: (data) => {
      console.log(data);
      if (loginManager.handleSignInResponse(data)) navigate("/mojezgloszenia");
    },
  });

  const onSignIn = async (user: { email: string; password: string }) => {
    signInMutation.mutate({
      email: user.email,
      password: user.password,
    });
  };

  return (
    <Form size="large" onFinish={onSignIn}>
      <Title>Login</Title>
      <Form.Item
        label="Email"
        labelCol={{ span: 24 }}
        name="email"
        rules={[
          {
            required: true,
            message: "Username is required",
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
      <Button htmlType="submit" type="primary">
        LOGIN
      </Button>
    </Form>
  );
};

export default SignInPage;
