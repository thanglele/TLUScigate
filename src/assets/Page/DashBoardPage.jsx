import React from 'react';
import SideBarLeft from '../components/SideBarLeft';
import MainContent from '../components/MainContent';
import FooterBoard from '../components/FooterBoard';

const DashBoardPage = () => {
  return (
    <div className="flex min-h-screen">
      {/* Sidebar bên trái */}
      <SideBarLeft />

      {/* Phần còn lại: MainContent và FooterBoard */}
      <div className="flex-1 flex flex-col">
        <MainContent />
        <FooterBoard year={"© 2025"}/>
      </div>
    </div>
  );
};

export default DashBoardPage;