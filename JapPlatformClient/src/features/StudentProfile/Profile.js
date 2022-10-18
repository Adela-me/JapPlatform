import dayjs from "dayjs";

import useProfile from "./useProfile";

import { Accordion } from "react-bootstrap";

const Profile = () => {
  const { data } = useProfile();

  return (
    <div>
      <h3 className="text-center my-5">
        Student Profile: {data?.firstName} {data?.lastName}
      </h3>

      <Accordion defaultActiveKey="0">
        <Accordion.Item eventKey="0">
          <Accordion.Header>Personal Info</Accordion.Header>
          <Accordion.Body>
            First name: {data?.firstName} <br />
            Last name: {data?.lastName} <br />
            Birth date: {data?.birthDate} <br />
          </Accordion.Body>
        </Accordion.Item>
        <Accordion.Item eventKey="1">
          <Accordion.Header>
            Selection Info: {data?.selection?.name}
          </Accordion.Header>
          <Accordion.Body>
            Start date: {dayjs(data?.selection?.startDate).format("YYYY-MM-DD")}
            <br />
            Status: {data?.selection?.status}
          </Accordion.Body>
        </Accordion.Item>
        <Accordion.Item eventKey="2">
          <Accordion.Header>
            Program Info: {data?.selection?.program?.name}
          </Accordion.Header>
          <Accordion.Body>
            {data?.selection?.program?.description}
          </Accordion.Body>
        </Accordion.Item>
      </Accordion>
    </div>
  );
};

export default Profile;
