// src/components/auth/HeaderLeftContent.tsx
import React from "react";
import "../../index.css";

interface HeaderLeftContentProps {
  value: string;
}

const HeaderLeftContent: React.FC<HeaderLeftContentProps> = ({ value }) => {
  return (
    <div className="absolute left-10 top-10 font-extrabold text-white text-2xl font-vt323">
      {value}
    </div>
  );
};

export default HeaderLeftContent;