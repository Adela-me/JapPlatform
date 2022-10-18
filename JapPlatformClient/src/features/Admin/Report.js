import TableBody from "components/Table/TableBody";
import TableHead from "components/Table/TableHead";
import { Table } from "react-bootstrap";
import { tableData } from "./ReportTableData";
import useReport from "./useReport";

export const Report = () => {
  const { data } = useReport();
  return (
    <Table size="sm" responsive>
      <TableHead tableData={tableData} />
      <TableBody dataRows={data} tableData={tableData} />
    </Table>
  );
};
