// src/components/InputField.tsx
import React from "react";

interface InputFieldProps {
  label: string;
  placeHolder: string;
  type: string;
  fontLabel?: string;
  icon?: React.ReactNode;
  onChange?: (e: React.ChangeEvent<HTMLInputElement>) => void;
  borderClass?: string;
  value?: string;
  onKeyDown?: (e: React.KeyboardEvent<HTMLInputElement>) => void;
}

const InputField: React.FC<InputFieldProps> = ({
  label,
  placeHolder,
  type,
  fontLabel,
  icon,
  onChange,
  borderClass,
  value,
  onKeyDown,
}) => {
  return (
    <div className="flex flex-col gap-2 mb-3">
      <label className={`block text-gray-700 ${fontLabel}`}>{label}</label>
      <div className="relative">
        <input
          type={type}
          placeholder={placeHolder}
          value={value}
          onChange={onChange}
          onKeyDown={onKeyDown}
          className={`mt-1 block w-full p-2 border ${borderClass || "border-gray-300"} rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 pr-10`}
        />
        {icon && (
          <span className="absolute inset-y-0 right-3 flex items-center text-gray-500">
            {icon}
          </span>
        )}
      </div>
    </div>
  );
};

export default InputField;