import { FunctionComponent } from "react";
import { useQuery } from "@tanstack/react-query";
import { AccountUser } from "../../../../types/User";
import axios from "axios";

const UserBalance: FunctionComponent = () => {
  const { data } = useQuery<AccountUser>({
    queryKey: ["user"],
    queryFn: () => {
      return axios.get(`/User`);
    },
    onSuccess: (data) => {
      // console.log(data);
    },
  });

  // TODO: Jakieś dane

  return null;
};

export default UserBalance;
