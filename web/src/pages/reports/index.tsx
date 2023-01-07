import { Button, Modal, Table, Tooltip } from "antd";
import { FunctionComponent, useEffect, useState } from "react";
import { Typography } from "antd";
import { Report } from "../../types/Report";
import type { TablePaginationConfig } from "antd/es/table";
import { Link } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import axios from "axios";

interface TableParams {
  pagination?: TablePaginationConfig;
}

const ReportsPage: FunctionComponent = () => {
  const columns = [
    {
      title: "Adres",
      dataIndex: "address",
      key: "address",
      width: "15%",
    },
    {
      title: "Gatunek",
      dataIndex: "animalType",
      key: "animalType",
      width: "15%",
    },
    {
      title: "Data zgłoszenia",
      dataIndex: "reportDate",
      key: "reportDate",
      width: "20%",
    },
    {
      title: "Zdjęcie",
      dataIndex: "imageUrl",
      render: (imageUrl: string) => (
        <img alt={imageUrl} src={imageUrl} width="250" height="250" />
      ),
      width: "35%",
    },
    {
      width: "10%",
      dataIndex: "id",
      render: (id: string) => (
        <Link to={`/zgloszenia/${id}`}>Pokaż szczegóły</Link>
      ),
    },
  ];

  const [isDetailModalOpen, setIsDetailModalOpen] = useState(false);
  const [isImageModalOpen, setIsImageModalOpen] = useState(false);
  const [reportDetail, setReportDetails] = useState<Report>({
    id: "",
    address: "",
    animalType: "",
    description: "",
    imageUrl: "",
    latitude: "",
    longitude: "",
    reportDate: "",
    status: "",
  });
  const { Title } = Typography;
  const [tableParams, setTableParams] = useState<TableParams>({
    pagination: {
      current: 1,
      pageSize: 5,
      total: 0,
    },
  });

  const handleTableChange = (pagination: TablePaginationConfig) => {
    setTableParams({
      pagination,
    });
  };

  const { data } = useQuery<{ data: { items: Report[] } }>({
    queryKey: ["reports"],
    queryFn: () => {
      return axios.get(`/client/reports`, {
        params: {
          pageNumber: tableParams.pagination?.current,
          pageSize: tableParams.pagination?.pageSize,
        },
      });
    },
    onSuccess: (data) => {
      console.log(data);
    },
  });

  const reports = data?.data?.items;

  const handleOk = () => {
    setIsDetailModalOpen(false);
    setIsImageModalOpen(false);
  };

  const handleCancel = () => {
    setIsDetailModalOpen(false);
    setIsImageModalOpen(false);
  };

  return (
    <>
      <Title level={1}>Zgłoszenia</Title>
      <Table
        sticky={true}
        dataSource={reports}
        columns={columns}
        pagination={tableParams.pagination}
        rowKey={(record) => record.id}
        onChange={handleTableChange}
        onRow={(record) => {
          return {
            onClick: (event) => {
              if (event.target.toString() === "[object HTMLImageElement]") {
                setIsImageModalOpen(true);
              } else {
                setIsDetailModalOpen(true);
              }
              setReportDetails(record);
            },
          };
        }}
      />
      <Modal
        title={
          reportDetail.animalType == "Dog"
            ? "Pies"
            : reportDetail.animalType == "Cat"
            ? "Kot"
            : reportDetail.animalType == "Opposum"
            ? "Opos"
            : "Nieznany gatunek"
        }
        open={isDetailModalOpen}
        onOk={handleOk}
        onCancel={handleCancel}
        footer={[
          <Button key="submit" type="primary" onClick={handleOk}>
            Ok
          </Button>,
        ]}
      >
        <p>
          Gatunek:{" "}
          {reportDetail.animalType == "Dog"
            ? "Pies"
            : reportDetail.animalType == "Cat"
            ? "Kot"
            : reportDetail.animalType == "Opposum"
            ? "Opos"
            : "Nieznany gatunek"}
        </p>
        <p>Opis: {reportDetail.description}</p>
        <p>Miejsce zdarzenia: {reportDetail.address}</p>
        <p>Data utworzenia: {reportDetail.reportDate}</p>
        <img
          alt={reportDetail.imageUrl}
          src={reportDetail.imageUrl}
          width="250"
          height="250"
        />
      </Modal>

      <Modal
        title={
          reportDetail.animalType == "Dog"
            ? "Pies"
            : reportDetail.animalType == "Cat"
            ? "Kot"
            : reportDetail.animalType == "Opposum"
            ? "Opos"
            : "Nieznany gatunek"
        }
        open={isImageModalOpen}
        onOk={handleOk}
        onCancel={handleCancel}
        width={"40%"}
        footer={[
          <Button key="submit" type="primary" onClick={handleOk}>
            Ok
          </Button>,
        ]}
      >
        <img
          alt={reportDetail.animalType}
          src={reportDetail.imageUrl}
          width="100%"
          height="100%"
        />
      </Modal>
    </>
  );
};

export default ReportsPage;
