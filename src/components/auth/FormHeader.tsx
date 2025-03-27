// src/components/FormHeader.tsx
import React from "react";

interface FormHeaderProps {
  values?: string;
  datas?:React.ReactNode;
  className?: string;
}

const FormHeader: React.FC<FormHeaderProps> = ({ values, className }) => {
  return (
    <div className="flex justify-between items-center mb-3">
      <h3 className={className}>{values}</h3>
      <img
        src="https://cdn.thanglele08.id.vn/img/logo-dai-hoc-thuy-loi-inkythuatso.svg"
        alt="Logo"
        className="w-20 h-20"
      />
    </div>
  );
};

export default FormHeader;