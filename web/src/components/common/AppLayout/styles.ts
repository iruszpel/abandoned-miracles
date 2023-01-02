import { Layout } from "antd";
import { Content } from "antd/es/layout/layout";
import styled from "styled-components";

export const LayoutWrapper = styled(Layout)`
  flex-direction: row;
  height: 100vh;
`;

export const ContentWrapper = styled(Content)`
  display: flex;
  flex: 1;
  flex-direction: column;
  margin: 8px 16px 32px;
  padding: 0;
  overflow: auto;

  background-color: #fff;
  border-radius: 8px;
`;

export const ContentInsideWrapper = styled.div`
  padding: 32px;
  overflow: auto;
`;

export const LogoWrapper = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  margin: 24px 0;
`;
