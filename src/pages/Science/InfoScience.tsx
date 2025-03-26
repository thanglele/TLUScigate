// src/components/AddScience.jsx
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createScience } from '../../api/scienceAPI.js';

const InfoScience = () => {
  const navigate = useNavigate();

  // State cho các trường trong form
  const [formData, setFormData] = useState({
    maCongBo: '',
    tieuDe: '',
    tomTat: '',
    tuKhoa: '',
    ngonNgu: '',
    loaiCongBo: 'Tạp chí trong nước',
    issnIsbn: '',
    chiMucKhoaHoc: 'Tạp chí trong nước',
    impactFactor: '',
    doi: '',
    namCongBo: '',
    soTrang: '',
    fileDinhKem: '',
    tacGia: '',
    email: '',
    hocHam: 'PGS',
    hocVi: 'Tiến sĩ',
    chucVi: '',
  });

  const [loading, setLoading] = useState(false);

  // Xử lý thay đổi input
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  // Xử lý file upload (file đính kèm)
  const handleFileChange = (e) => {
    const file = e.target.files[0];
    setFormData((prev) => ({
      ...prev,
      fileDinhKem: file ? file : '', // Lưu file object thay vì chỉ tên file
    }));
  };

  // Xử lý submit form
  const handleSubmit = async () => {
    setLoading(true);

    // Kiểm tra các trường bắt buộc trước khi gửi
    const requiredFields = ['maCongBo', 'tieuDe', 'tomTat', 'namCongBo', 'tacGia'];
    const missingFields = requiredFields.filter((field) => !formData[field].trim());
    if (missingFields.length > 0) {
      alert(`Vui lòng điền các trường bắt buộc: ${missingFields.join(', ')}`);
      setLoading(false);
      return;
    }

    try {
      // Chuẩn bị dữ liệu gửi lên API
      const dataToSend = {
        ...formData,
        impactFactor: formData.impactFactor || 0,
        soTrang: formData.soTrang || 0,
      };

      // Gửi dữ liệu lên API
      await createScience(dataToSend);

      // Hiển thị thông báo thành công bằng alert()
      alert('Công bố khoa học đã được thêm thành công!');

      // Chuyển hướng về /science-tables sau 2 giây
      setTimeout(() => {
        navigate('/science-tables');
      }, 2000);
    } catch (error) {
      // Hiển thị lỗi chi tiết từ API
      alert(error.message);
    } finally {
      setLoading(false);
    }
  };

  const RequiredLabel = ({ children }) => (
    <span className="text-sm font-medium text-gray-700 dark:text-gray-200">
      {children} <span className="text-red-500">*</span>
    </span>
  );

  return (
    <div className="p-6 bg-white rounded-lg shadow-sm dark:bg-gray-800">
      <h1 className="text-2xl font-bold mb-6 text-gray-800 dark:text-white">
        Đăng ký bài công bố khoa học
      </h1>
      <div className="pb-4">
        <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
          1. Thông tin bài công bố
        </span>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          <div>
            <RequiredLabel>Mã công bố</RequiredLabel>
            <input
              type="text"
              name="maCongBo"
              value={formData.maCongBo}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập mã công bố"
            />
          </div>
          <div>
            <RequiredLabel>Tiêu đề</RequiredLabel>
            <input
              type="text"
              name="tieuDe"
              value={formData.tieuDe}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập tiêu đề"
            />
          </div>
        </div>
        <div className="grid grid-cols-1 md:grid-cols-1 gap-4">
          <div>
            <RequiredLabel>Tóm tắt</RequiredLabel>
            <textarea
              name="tomTat"
              value={formData.tomTat}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập tóm tắt"
            />
          </div>
        </div>
        <div className="grid grid-cols-1 md:grid-cols-1 gap-4">
          <div>
            <RequiredLabel>Từ khóa</RequiredLabel>
            <input
              type="text"
              name="tukhoa"
              value={formData.tuKhoa}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập từ khóa"
            />
          </div>
        </div>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4 pt-2">
          <div>
            <RequiredLabel>Ngôn Ngữ</RequiredLabel>
            <input
              type="text"
              name="ngonNgu"
              value={formData.ngonNgu}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập ngôn ngữ"
            />
          </div>
          <div>
            <RequiredLabel>Loại công bố</RequiredLabel>
            <select
              name="loaiCongBo"
              value={formData.loaiCongBo}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
            >
              <option>Tạp chí trong nước</option>
              <option>Tạp chí quốc tế</option>
            </select>
          </div>
          <div>
            <RequiredLabel>ISSN_ISBN Mã công bố:</RequiredLabel>
            <input
              type="text"
              name="issnIsbn"
              value={formData.issnIsbn}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập ISSN_ISBN"
            />
          </div>
          <div>
            <RequiredLabel>Chỉ mục khoa học</RequiredLabel>
            <select
              name="chiMucKhoaHoc"
              value={formData.chiMucKhoaHoc}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
            >
              <option>Tạp chí trong nước</option>
              <option>Tạp chí quốc tế</option>
            </select>
          </div>
        </div>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4 pt-2">
          <div>
            <RequiredLabel>Impact Factor</RequiredLabel>
            <input
              type="number"
              name="impactFactor"
              value={formData.impactFactor}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập Impact Factor"
            />
          </div>
          <div>
            <RequiredLabel>DOI</RequiredLabel>
            <input
              type="text"
              name="doi"
              value={formData.doi}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập DOI"
            />
          </div>
          <div>
            <RequiredLabel>Năm công bố</RequiredLabel>
            <input
              type="number"
              name="namCongBo"
              value={formData.namCongBo}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập năm (VD: 2023)"
            />
          </div>
        </div>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4 pt-2">
          <div>
            <RequiredLabel>Số trang</RequiredLabel>
            <input
              type="number"
              name="soTrang"
              value={formData.soTrang}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập số trang"
            />
          </div>
          <div>
            <RequiredLabel>File đính kèm</RequiredLabel>
            <input
              type="file"
              name="fileDinhKem"
              onChange={handleFileChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder=""
            />
          </div>
        </div>
      </div>

      {/* Thông tin tác giả */}
      <div className="pb-4">
        <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
          2. Thông tin tác giả
        </span>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4 pt-2">
          <div>
            <RequiredLabel>Tác giả</RequiredLabel>
            <input
              type="text"
              name="tacGia"
              value={formData.tacGia}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập tên tác giả"
            />
          </div>
          <div>
            <RequiredLabel>Email</RequiredLabel>
            <input
              type="email"
              name="email"
              value={formData.email}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập email"
            />
          </div>
        </div>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4 pt-2">
          <div>
            <RequiredLabel>Học hàm</RequiredLabel>
            <select
              name="hocHam"
              value={formData.hocHam}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
            >
              <option>PGS</option>
              <option>Giáo Sư</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Học vị</RequiredLabel>
            <select
              name="hocVi"
              value={formData.hocVi}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
            >
              <option>Tiến sĩ</option>
              <option>Thạc sĩ</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Chức vị</RequiredLabel>
            <input
              type="text"
              name="chucVi"
              value={formData.chucVi}
              onChange={handleChange}
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập chức vị"
            />
          </div>
        </div>
      </div>

      <div className="space-y-6">
        <div className="flex justify-end gap-3 pt-6">
          <button
            className="px-6 py-2 text-gray-700 bg-gray-100 rounded-lg hover:bg-gray-200 dark:bg-gray-600 dark:text-gray-200"
            onClick={() => navigate('/science-tables')}
          >
            Hủy
          </button>
          <button
            className="px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 dark:bg-blue-700 dark:hover:bg-blue-800"
            onClick={handleSubmit}
            disabled={loading}
          >
            {loading ? 'Đang xử lý...' : 'Đăng Ký'}
          </button>
        </div>
      </div>
    </div>
  );
};

export default InfoScience;