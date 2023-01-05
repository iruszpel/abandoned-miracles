import { Button, Modal, Table } from "antd";
import { FunctionComponent, useState } from "react";
import { Typography } from "antd";

type Animal = {
  key: string;
  name: string;
  species: string;
  color: string;
  date: string;
  ImageURL: string;
};

const MyReportsPage: FunctionComponent = () => {
  const [isDetailModalOpen, setIsDetailModalOpen] = useState(false);
  const [animalDetails, setAnimalDetails] = useState<Animal>({
    key: "",
    name: "",
    species: "",
    color: "",
    date: "",
    ImageURL: "",
  });
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

  const dataSource = [
    {
      key: "1",
      name: "Mike",
      species: "Goat",
      color: "White",
      date: "2014-12-24 23:12:00",
      ImageURL:
        "https://bi.im-g.pl/im/07/48/1b/z28607751IER,koza---zdjecie-ilustracyjne.jpg",
    },
    {
      key: "2",
      name: "Unknown",
      species: "Hyena",
      color: "Hyenaish",
      date: "2014-12-24 23:12:00",
      ImageURL: "http://www.drapiezniki.pl/Photos/hiena.jpg",
    },
    {
      key: "3",
      name: "Chupacabra",
      species: "Unknown",
      color: "Dark",
      date: "2014-12-24 23:12:00",
      ImageURL:
        "https://scroll.morele.net/wp-content/uploads/2021/11/chupacabra2-1024x683.jpg",
    },
  ];

  const columns = [
    {
      title: "Imię",
      dataIndex: "name",
      key: "name",
      width: "15%",
    },
    {
      title: "Gatunek",
      dataIndex: "species",
      key: "species",
      width: "15%",
    },
    {
      title: "Kolor",
      dataIndex: "color",
      key: "color",
      width: "15%",
    },
    {
      title: "Date",
      dataIndex: "date",
      key: "date",
      width: "20%",
    },
    {
      title: "Zdjęcie",
      dataIndex: "ImageURL",
      render: (theImageURL: string) => (
        <img alt={theImageURL} src={theImageURL} width="300" height="200" />
      ),
      width: "35%",
    },
  ];

  return (
    <>
      <Title level={1}>Moje zgłoszenia</Title>
      <Table
        dataSource={dataSource}
        columns={columns}
        pagination={false}
        sticky={true}
        onRow={(record, rowIndex) => {
          return {
            onClick: (event) => {
              setIsDetailModalOpen(true);
              setAnimalDetails(record);
            },
          };
        }}
      />
      <Modal
        title={animalDetails.name}
        open={isDetailModalOpen}
        onOk={handleOk}
        onCancel={handleCancel}
        footer={[
          <Button key="submit" type="dashed" onClick={handleOk}>
            Usuń
          </Button>,
          <Button key="delete" type="primary" onClick={handleDelete}>
            Ok
          </Button>,
        ]}
      >
        <p>Gatunek: {animalDetails.species}</p>
        <p>Kolor: {animalDetails.color}</p>
        <p>Data utworzenia zgłoszenia: {animalDetails.date}</p>
        <img
          alt={animalDetails.ImageURL}
          src={animalDetails.ImageURL}
          width="400"
          height="200"
        />
      </Modal>
    </>
  );
};

export default MyReportsPage;
