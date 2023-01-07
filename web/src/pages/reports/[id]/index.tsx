import {
  Button,
  Descriptions,
  Divider,
  message,
  Modal,
  Popconfirm,
  Table,
  Tag,
  Tooltip,
} from "antd";
import { FunctionComponent, useEffect, useMemo, useState } from "react";
import { Typography } from "antd";
import { Report } from "../../../types/Report";
import type { TablePaginationConfig } from "antd/es/table";
import { Link, useNavigate, useParams } from "react-router-dom";
import { useMutation, useQuery } from "@tanstack/react-query";
import axios from "axios";
import {
  AzureMap,
  AzureMapFeature,
  AzureMapHtmlMarker,
  AzureMapsProvider,
  IAzureDataSourceChildren,
  IAzureMapOptions,
} from "react-azure-maps";
import {
  AuthenticationType,
  data as mapsData,
  HtmlMarkerOptions,
} from "azure-maps-control";
import { PushpinOutlined } from "@ant-design/icons";
import { queryClient } from "../../../App";

interface TableParams {
  pagination?: TablePaginationConfig;
}

function azureHtmlMapMarkerOptions(
  coordinates: mapsData.Position
): HtmlMarkerOptions {
  return {
    position: coordinates,
    text: "My text",
    title: "Title",
  };
}

const { Title } = Typography;

const ReportDetailsPage: FunctionComponent = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();

  const { data } = useQuery<{ data: { items: Report[] } }>({
    queryKey: ["reports"],
    queryFn: (data) => {
      return axios.get(`/client/reports`, {
        params: {
          pageNumber: 1,
          pageSize: 10,
        },
      });
    },
  });

  const closeReportMutation = useMutation({
    mutationFn: (report: { reportId: string }) => {
      return axios.post(`/serviceworker/close-report`, {
        reportId: report.reportId,
      });
    },
    onSuccess: (data) => {
      message.success("Zgłoszenie zostało zamknięte");
      queryClient.invalidateQueries(["reports"]);
      navigate("/mojezgloszenia");
    },
    onError: (error) => {
      message.error("Nie udało się zamknąć zgłoszenia");
    },
  });

  const onClose = async (report: { reportId: string }) => {
    closeReportMutation.mutate({ reportId: report.reportId });
  };

  const reports = data?.data?.items;

  const reportDetails = reports?.find((report: Report) => report.id === id);

  const mapOptions: IAzureMapOptions = useMemo(
    () => ({
      authOptions: {
        authType: AuthenticationType.subscriptionKey,
        subscriptionKey: import.meta.env.VITE_AZURE_MAPS_KEY,
      },

      center: reportDetails
        ? [
            Number(reportDetails?.longitude) || 0,
            Number(reportDetails?.latitude) || 0,
          ]
        : undefined,
      zoom: 8,
    }),
    [reportDetails]
  );

  return (
    <div>
      <Title level={2}>Szczegóły zgłoszenia</Title>
      <Descriptions
        bordered
        title="Informacje o zgłoszeniu"
        extra={
          <Tag color={reportDetails?.status === "Open" ? "green" : "red"}>
            {reportDetails?.status === "Open" ? "Otwarte" : "Zamknięte"}
          </Tag>
        }
      >
        <Descriptions.Item label="Adres">
          {reportDetails?.address}
        </Descriptions.Item>
        <Descriptions.Item label="Gatunek">
          {reportDetails?.animalType}
        </Descriptions.Item>
        <Descriptions.Item label="Data zgłoszenia">
          {reportDetails?.reportDate}
        </Descriptions.Item>
        <Descriptions.Item label="Zdjęcie">
          <img
            alt={reportDetails?.imageUrl}
            src={reportDetails?.imageUrl}
            width="250"
            height="250"
          />
        </Descriptions.Item>

        <Descriptions.Item label="Opis">
          {reportDetails?.description}
        </Descriptions.Item>

        <Descriptions.Item label="Szerokość geograficzna">
          {reportDetails?.latitude}
        </Descriptions.Item>

        <Descriptions.Item label="Długość geograficzna">
          {reportDetails?.longitude}
        </Descriptions.Item>
      </Descriptions>
      <Divider />
      {reportDetails?.latitude && reportDetails?.longitude && (
        <div style={{ height: "600px" }}>
          <AzureMapsProvider>
            <AzureMap options={mapOptions}>
              <AzureMapFeature
                key={1}
                id="pin"
                type="Point"
                coordinate={[
                  Number(reportDetails?.longitude),
                  Number(reportDetails?.latitude),
                ]}
                properties={{
                  title: "Pin",
                  icon: "pin-round-blue",
                }}
              />

              <AzureMapHtmlMarker
                key={2}
                markerContent={
                  <PushpinOutlined
                    style={{
                      fontSize: "20px",
                      color: "red",
                    }}
                  />
                }
                options={
                  {
                    ...azureHtmlMapMarkerOptions(
                      new mapsData.Position(
                        Number(reportDetails?.longitude),
                        Number(reportDetails?.latitude)
                      )
                    ),
                  } as any
                }
              />
            </AzureMap>
          </AzureMapsProvider>
        </div>
      )}
      <Divider />
      <Popconfirm
        title="Czy na pewno chcesz zamknąć zgłoszenie?"
        onConfirm={() => onClose({ reportId: reportDetails?.id! })}
      >
        <Button danger>Zamknij zgłoszenie</Button>
      </Popconfirm>
    </div>
  );
};

export default ReportDetailsPage;
