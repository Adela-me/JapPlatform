import { Col, Container, Row } from "react-bootstrap";

import ProgramsTable from "features/Programs/ProgramsTable";

const Programs = () => {
  return (
    <Container
      style={{ height: "100vh" }}
      className="d-flex align-items-center"
    >
      <Row className=" w-100  justify-content-center">
        <h1 className="text-center mb-4">Programs</h1>
        <Col className="border rounded p-3 bg-light">
          <ProgramsTable />
        </Col>
      </Row>
    </Container>
  );
};

export default Programs;
