import { useNavigate } from 'react-router-dom';

interface BreadcrumbProps {
  pageTitle: string;
}

const PageBreadcrumb: React.FC<BreadcrumbProps> = ({ pageTitle }) => {
  const navigate = useNavigate();

  const handleAddClick = () => {
    navigate('/them-giang-vien');
  };

  return (
    <div className="flex flex-wrap items-center justify-between gap-3 mb-6">
      <h2 className="text-xl font-semibold text-gray-800 dark:text-white/90">
        {pageTitle}
      </h2>
      <div className="action">
        <button 
          onClick={handleAddClick}
          className="flex items-center gap-1.5 px-5 py-1.5 bg-[#145efc] hover:bg-[#145efc]/90 text-white rounded-lg transition-all duration-200 dark:bg-[#145efc] dark:hover:bg-[#145efc]/80"
        >
          <span className="text-lg font-bold">+</span>
          Thêm
        </button>
      </div>
    </div>
  );
};

export default PageBreadcrumb;

