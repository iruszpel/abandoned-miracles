import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import AppLayout from "./components/common/AppLayout";
import { Route, Routes } from "react-router";
import { Result } from "antd";
import React, { useEffect } from "react";
import { BrowserRouter } from "react-router-dom";
import SignInPage from "./pages/signin";
import ReportsPage from "./pages/reports";
import SignUpPage from "./pages/signup";
import axios from "axios";
import loginManager from "./utils/auth/loginManager";
import { API_URL } from "./utils/vars";

export const queryClient = new QueryClient();

function App() {
  useEffect(() => {
    axios.defaults.baseURL = API_URL;
    axios.defaults.headers.common["Content-Type"] = "application/json";
    loginManager.authorizationHeader &&
      (axios.defaults.headers.common["Authorization"] =
        loginManager.authorizationHeader);
  }, []);

  return (
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <AppLayout>
          <Routes>
            <Route element={<></>} path="/" />
            <Route element={<SignInPage />} path="/signin" />
            <Route element={<SignUpPage />} path="/signup" />
            <Route element={<ReportsPage />} path="/zgloszenia" />
            <Route
              element={
                <Result
                  status="404"
                  subTitle="Sorry, the page you visited does not exist."
                  title="404"
                />
              }
              path="*"
            />
          </Routes>
        </AppLayout>
      </BrowserRouter>
    </QueryClientProvider>
  );
}

export const withAppLayout = (Component: React.ComponentType) => () =>
  (
    <AppLayout>
      <Component />
    </AppLayout>
  );

export default App;