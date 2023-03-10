import { Button, Modal, Table, Tag } from "antd";
import { FunctionComponent, useEffect, useState } from "react";
import { Typography } from "antd";
import { Report } from "../../types/Report";
import { API_URL } from "../../utils/vars";

const MyReportsPage: FunctionComponent = () => {
  const [isDetailModalOpen, setIsDetailModalOpen] = useState(false);
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
  const [reports, setReports] = useState<Report[]>([]);
  const { Title } = Typography;

  const handleOk = () => {
    setIsDetailModalOpen(false);
  };

  const handleDelete = () => {
    setIsDetailModalOpen(false);
  };

  const handleCancel = () => {
    setIsDetailModalOpen(false);
  };

  async function fetchReports() {
    const response = await fetch(`${API_URL}/client/my-reports`, {
      method: "GET",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": "*",
        Authorization: "Bearer " + localStorage.getItem("user"),
      },
    });
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    const data = await response.json();

    const mappedData = data.map((report: Report) => {
      return {
        key: report.id,
        address: report.address,
        animalType: report.animalType,
        description: report.description,
        imageUrl: report.imageUrl,
        latitude: report.latitude,
        longitude: report.longitude,
        reportDate: report.reportDate,
        status: report.status,
      };
    });
    setReports(data);
  }

  useEffect(() => {
    fetchReports();
  }, []);

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
      title: "Data zg??oszenia",
      dataIndex: "reportDate",
      key: "reportDate",
      width: "20%",
    },
    {
      title: "Zdj??cie",
      dataIndex: "imageUrl",
      render: (imageUrl: string) => (
        <img alt={imageUrl} src={imageUrl} width="300" height="200" />
      ),
      width: "35%",
    },
    {
      title: "Status",
      dataIndex: "status",
      key: "status",
      width: "15%",
      render: (status: string) => (
        <Tag color={status == "Open" ? "green" : "red"}>{status}</Tag>
      ),
    },
  ];

  return (
    <>
      <Title level={1}>Moje zg??oszenia</Title>
      <Table
        dataSource={reports}
        columns={columns}
        pagination={false}
        sticky={true}
        rowKey={(record) => record.id}
        onRow={(record, rowIndex) => {
          return {
            onClick: (event) => {
              setIsDetailModalOpen(true);
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
          <Button key="delete" type="primary" onClick={handleDelete}>
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
        <p>
          Status zg??oszenia:{" "}
          {reportDetail.status == "Open" ? "Aktalne" : "Nieaktualne"}
        </p>
        <img
          alt={reportDetail.animalType}
          src={reportDetail.imageUrl}
          width="400"
          height="200"
        />
      </Modal>
    </>
  );
};

export default MyReportsPage;
