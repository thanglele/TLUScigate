// src/components/FormHeader.tsx
import React from "react";

interface FormHeaderProps {
  value: string;
  className?: string;
}

const FormHeader: React.FC<FormHeaderProps> = ({ value, className }) => {
  return (
    <div className="flex justify-between items-center mb-3">
      <h3 className={className}>{value}</h3>
      <img
        src="src/icons/logo-dai-hoc-thuy-loi-inkythuatso.svg"
        alt="Logo"
        className="w-20 h-20"
      />
    </div>
  );
};

export default FormHeader;