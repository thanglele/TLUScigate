// src/components/Button.tsx
import React from "react";

interface ButtonProps {
  value: string;
  color?: string;
  onClick?: () => void;
  textSize?: string;
  className?: string;
}

const Button: React.FC<ButtonProps> = ({ value, color, onClick, textSize, className }) => {
  return (
    <button
      className={`w-full p-2 rounded-md transition duration-200 font-bold text-sm ${color} text-white hover:bg-blue-700 mt-3 ${className}`}
      onClick={onClick}
    >
      <p className={textSize}>{value}</p>
    </button>
  );
};

export default Button;