import { FunctionComponent, useEffect } from "react";
import { RadarChartOutlined } from "@ant-design/icons";
import { Button, Layout, Menu, Space } from "antd";
import Sider from "antd/lib/layout/Sider";
import { Link, useMatch } from "react-router-dom";
import {
  ContentInsideWrapper,
  ContentWrapper,
  LayoutWrapper,
  LogoWrapper,
} from "./styles";
import logo from "./assets/logo.png";
import ButtonLink from "../ButtonLink";
import loginManager from "../../../utils/auth/loginManager";
import UserInfo from "./UserInfo";

type AppLayoutProps = {
  className?: string;
  children: React.ReactNode;
};

const menuItemsLoggedOut = [
  {
    key: "zgloszenia",
    link: "/signin",
    title: "Zgłoszenia",
    icon: <RadarChartOutlined />,
  },
  {
    key: "mojezgloszenia",
    link: "/signin",
    title: "Moje zgłoszenia",
    icon: <RadarChartOutlined />,
  },
] as const;

const menuItemsLoggedIn = [
  {
    key: "zgloszenia",
    link: "/zgloszenia",
    title: "Zgłoszenia",
    icon: <RadarChartOutlined />,
  },
  {
    key: "mojezgloszenia",
    link: "/mojezgloszenia",
    title: "Moje zgłoszenia",
    icon: <RadarChartOutlined />,
  },
] as const;

const AppLayout: FunctionComponent<AppLayoutProps> = ({ children }) => {
  const match = useMatch("/:card/*");

  return (
    <LayoutWrapper>
      <Sider theme="light" breakpoint="lg" collapsedWidth="0">
        <LogoWrapper>
          <img width="160" alt="Logo" src={logo} />
        </LogoWrapper>
        <Menu
          selectedKeys={[match?.params.card ?? ""]}
          mode="inline"
          theme="light"
        >
          {localStorage.getItem("user")
            ? menuItemsLoggedIn.map(({ key, title, link, icon }) => (
                <Menu.Item key={key} icon={icon}>
                  <Link to={link}>{title}</Link>
                </Menu.Item>
              ))
            : menuItemsLoggedOut.map(({ key, title, link, icon }) => (
                <Menu.Item key={key} icon={icon}>
                  <Link to={link}>{title}</Link>
                </Menu.Item>
              ))}
        </Menu>
        <Space
          direction="vertical"
          size="middle"
          style={{
            width: "100%",
            position: "absolute",
            bottom: 32,
            display: "flex",
            justifyContent: "center",
          }}
        >
          {!loginManager.isSignedIn ? (
            <>
              <ButtonLink to="/signin" type="primary" block>
                Zaloguj się
              </ButtonLink>
              <ButtonLink to="/signup" block>
                Zarejestruj się
              </ButtonLink>
            </>
          ) : (
            <Space
              direction="vertical"
              style={{
                width: "100%",
                position: "absolute",
                bottom: 32,
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
              }}
            >
              {loginManager.user?.email}
              <UserInfo />
              <Button onClick={loginManager.signOut} type="primary" block>
                Wyloguj się
              </Button>
            </Space>
          )}
        </Space>
      </Sider>
      <Layout>
        <ContentWrapper>
          <ContentInsideWrapper id="content-inside">
            {children}
          </ContentInsideWrapper>
        </ContentWrapper>
      </Layout>
    </LayoutWrapper>
  );
};

export default AppLayout;