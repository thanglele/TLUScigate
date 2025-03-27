// src/components/Form.tsx
import React from "react";

interface FormProps {
  children: React.ReactNode;
}

const Form: React.FC<FormProps> = ({ children }) => {
  return (
    <div className="bg-white p-5 rounded-xl md:w-2/3 w-2/3 text-sm mx-auto">
      {children}
    </div>
  );
};

export default Form;