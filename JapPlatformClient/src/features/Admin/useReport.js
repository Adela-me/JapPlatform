import { useQuery } from "@tanstack/react-query";
import axios from "axios";

import { urlReport } from "endpoints";

const getReport = async () => {
  const { data } = await axios.get(urlReport);
  return data.data;
};

export default function useReport() {
  return useQuery(["profile"], () => getReport(), {
    refetchOnWindowFocus: false,
  });
}
