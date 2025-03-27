// src/components/Link.tsx
import React from "react";

interface LinkProps {
  value: string;
  onClick?: () => void;
}

const Link: React.FC<LinkProps> = ({ value, onClick }) => {
  return (
    <a
      href="#"
      className="text-xs md:text-sm text-blue-600 hover:underline ml-auto items-center"
      onClick={onClick}
    >
      {value}
    </a>
  );
};

export default Link;