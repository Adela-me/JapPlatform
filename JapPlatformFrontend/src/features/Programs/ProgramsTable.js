import { Table } from "react-bootstrap";

import { tableData } from "./Programs.data";
import usePrograms from "./usePrograms";

import TableBody from "components/Table/TableBody";
import TableHead from "components/Table/TableHead";

const ProgramsTable = () => {
  const { data: programs } = usePrograms();

  return (
    <Table responsive>
      <TableHead tableData={tableData} />
      <TableBody dataRows={programs} tableData={tableData} />
    </Table>
  );
};

export default ProgramsTable;
