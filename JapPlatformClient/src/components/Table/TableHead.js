import { useStore } from "store";

const TableHead = ({ tableData, showActions }) => {
  const setSort = useStore((state) => state.setSort);
  const sort = useStore((state) => state.sort);

  const orderHandler = (e, sortBy) => {
    if (sort === sortBy) {
      setSort(sortBy + " desc");
    } else {
      setSort(sortBy);
    }
  };

  return (
    <thead>
      <tr>
        {tableData.map((data) => (
          <th key={data.header} onClick={(e) => orderHandler(e, data.prop)}>
            {data.header}
            {sort === data.prop && <i className="bi bi-chevron-up"></i>}
            {sort === data.prop + " desc" && (
              <i className="bi bi-chevron-down"></i>
            )}
          </th>
        ))}
        {showActions && <th key="action">Actions</th>}
      </tr>
    </thead>
  );
};

export default TableHead;
