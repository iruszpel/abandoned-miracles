import { Button, ButtonProps } from "antd";
import { FunctionComponent } from "react";
import { To, useHref } from "react-router";
import { useLinkClickHandler } from "react-router-dom";

type ButtonLinkProps = {
  to: To;
} & ButtonProps;

const ButtonLink: FunctionComponent<ButtonLinkProps> = ({
  to,
  target,
  onClick,
  ...rest
}) => {
  const href = useHref(to);

  const handleClick = useLinkClickHandler(to);

  return <Button href={href} target={target} onClick={handleClick} {...rest} />;
};

export default ButtonLink;
