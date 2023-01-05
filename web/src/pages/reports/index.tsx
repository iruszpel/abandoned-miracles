import { Button, Modal, Table, Tooltip } from "antd";
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

const ReportsPage: FunctionComponent = () => {
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
        <Tooltip title="Powiększ zdjęcie">
          <img alt={theImageURL} src={theImageURL} width="300" height="200" />
        </Tooltip>
      ),
      width: "35%",
    },
  ];

  const [isDetailModalOpen, setIsDetailModalOpen] = useState(false);
  const [isImageModalOpen, setIsImageModalOpen] = useState(false);
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
        dataSource={dataSource}
        columns={columns}
        pagination={false}
        sticky={true}
        onRow={(record, rowIndex) => {
          return {
            onClick: (event) => {
              if (event.target.toString() === "[object HTMLImageElement]") {
                setIsImageModalOpen(true);
              } else {
                setIsDetailModalOpen(true);
              }
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
          <Button key="submit" type="primary" onClick={handleOk}>
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

      <Modal
        title={animalDetails.name}
        open={isImageModalOpen}
        onOk={handleOk}
        onCancel={handleCancel}
        width={"50%"}
        footer={[
          <Button key="submit" type="primary" onClick={handleOk}>
            Ok
          </Button>,
        ]}
      >
        <img
          alt={animalDetails.ImageURL}
          src={animalDetails.ImageURL}
          width="100%"
          height="100%"
        />
      </Modal>
    </>
  );
};

export default ReportsPage;
