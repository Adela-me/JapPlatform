import { useQuery } from "@tanstack/react-query";
import axios from "axios";

import { urlProfile } from "endpoints";

const getProfile = async () => {
  const { data } = await axios.get(urlProfile);
  return data.data;
};

export default function useProfile() {
  return useQuery(["profile"], () => getProfile(), {
    refetchOnWindowFocus: false,
  });
}
