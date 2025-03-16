import React from 'react';

const MenuItem = ({ icon, label, isActive = false }) => {
  return (
    <div
      className={`flex-1 flex items-center p-3 mb-3 cursor-pointer transition-colors duration-200 rounded-2xl ${
        isActive ? 'bg-indigo-700 text-white' : 'text-gray-600 hover:bg-gray-100'
      }`}
    >
      <span className="mr-3">{icon}</span>
      <span className="text-sm font-medium">{label}</span>
    </div>
  );
};

export default MenuItem;