import React from 'react';

const Card = ({ icon, label }) => {
  return (
    <div className={"bg-blue-500 p-6 hover:bg-blue-800 rounded-lg flex flex-col items-center justify-center h-50 gap-3"}>
      <span className="text-3xl mb-3">{icon}</span>
      <span className="antialiased text-2xl font-sans font-light text-white">{label}</span>
    </div>
  );
};

export default Card;