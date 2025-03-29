import { useState } from "react";
import { useNavigate } from "react-router-dom";
// @ts-ignore
import { createNCKHGiangVien } from "../../api/NCKHGiangVienAPI";

interface TopicData {
  maDeTai: string;
  tenDeTai: string;
  linhVucNghienCuu: string[];
  chuNhiemDeTai: string;
  nganh: string;
  khoa: string;
  ngayBatDau: string;
  ngayKetThuc: string;
  kinhPhi: number;
  nguonKinhPhi: string;
  mucTieu: string;
  ketQuaDuKien: string;
}

const NewTopicFormFaculty = () => {
  const navigate = useNavigate();
  const [topicData, setTopicData] = useState<TopicData>({
    maDeTai: "",
    tenDeTai: "",
    linhVucNghienCuu: [],
    chuNhiemDeTai: "",
    nganh: "",
    khoa: "",
    ngayBatDau: "",
    ngayKetThuc: "",
    kinhPhi: 0,
    nguonKinhPhi: "",
    mucTieu: "",
    ketQuaDuKien: "",
  });

  const handleAddTopic = async () => {
    try {
      await createNCKHGiangVien(topicData);
      navigate("/giang-vien-nghien-cuu"); // Chuyển hướng sau khi thêm thành công
    } catch (error) {
      console.error("Error adding topic data:", error);
    }
  };

  const RequiredLabel = ({ children }: { children: string }) => (
    <span className="text-sm font-medium text-gray-700 dark:text-gray-200">
      {children} <span className="text-red-500">*</span>
    </span>
  );

  return (
    <div className="p-6 bg-white rounded-lg shadow-sm dark:bg-gray-800">
      <h1 className="text-2xl font-bold mb-6 text-gray-800 dark:text-white">
        ĐĂNG KÍ ĐỀ TÀI NGHIÊN CỨU ĐỐI VỚI GIẢNG VIÊN
      </h1>
      <div className="pb-4">
        <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
          1. Thông tin chung
        </span>
        <div className="grid pb-5 grid-cols-1 md:grid-cols-3 gap-4">
          <div>
            <RequiredLabel>Tên đề tài</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Tên đề tài nghiên cứu"
              value={topicData.tenDeTai}
              onChange={(e) =>
                setTopicData({ ...topicData, tenDeTai: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Mã đề tài</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Mã đề tài"
              value={topicData.maDeTai}
              onChange={(e) =>
                setTopicData({ ...topicData, maDeTai: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Lĩnh vực nghiên cứu</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Lĩnh vực nghiên cứu"
              value={topicData.linhVucNghienCuu.join(", ")}
              onChange={(e) =>
                setTopicData({
                  ...topicData,
                  linhVucNghienCuu: e.target.value.split(", "),
                })
              }
            />
          </div>
        </div>
        <div className="grid pb-5 grid-cols-1 md:grid-cols-3 gap-4">
          <div>
            <RequiredLabel>Chủ nhiệm đề tài</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Tên chủ nhiệm đề tài"
              value={topicData.chuNhiemDeTai}
              onChange={(e) =>
                setTopicData({ ...topicData, chuNhiemDeTai: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Ngành</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Chọn ngành"
              value={topicData.nganh}
              onChange={(e) =>
                setTopicData({ ...topicData, nganh: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Khoa</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Chọn khoa"
              value={topicData.khoa}
              onChange={(e) =>
                setTopicData({ ...topicData, khoa: e.target.value })
              }
            />
          </div>
        </div>
      </div>
      {/* THỜI GIAN THỰC HIỆN */}
      <div className="pb-4">
        <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
          2. Thời gian thực hiện
        </span>
        <div className="grid pb-5 grid-cols-1 md:grid-cols-2 gap-4 pt-2">
          <div>
            <RequiredLabel>Ngày bắt đầu</RequiredLabel>
            <input
              type="date"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={topicData.ngayBatDau}
              onChange={(e) =>
                setTopicData({ ...topicData, ngayBatDau: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Ngày kết thúc dự kiến</RequiredLabel>
            <input
              type="date"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={topicData.ngayKetThuc}
              onChange={(e) =>
                setTopicData({ ...topicData, ngayKetThuc: e.target.value })
              }
            />
          </div>
        </div>
      </div>
      {/* THỜI GIAN THỰC HIỆN */}
      <div className="pb-4">
        <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
          3. Kinh phí và tài trợ
        </span>
        <div className="grid pb-5 grid-cols-1 md:grid-cols-2 gap-4 pt-2">
          <div>
            <RequiredLabel>Tổng kinh phí và tài trợ</RequiredLabel>
            <input
              type="number"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập số tiền (VD: 5000000)"
              value={topicData.kinhPhi}
              onChange={(e) =>
                setTopicData({ ...topicData, kinhPhi: Number(e.target.value) })
              }
            />
          </div>
          <div>
            <RequiredLabel>Nguồn tài trợ</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={topicData.nguonKinhPhi}
              onChange={(e) =>
                setTopicData({ ...topicData, nguonKinhPhi: e.target.value })
              }
            />
          </div>
        </div>
      </div>
      <div className="pb-4">
        <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
          4. Nội dung nghiên cứu
        </span>
        <div className="grid pb-5 grid-cols-1 md:grid-cols-1 gap-4 pt-2">
          <div>
            <RequiredLabel>Giới thiệu tổng quan về đề tài</RequiredLabel>
            <textarea
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Giới thiệu và lý do"
              value={topicData.mucTieu}
              onChange={(e) =>
                setTopicData({ ...topicData, mucTieu: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Tính cấp thiết của đề tài</RequiredLabel>
            <textarea
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Tầm quan trọng, tính thời sự hoặc cấp bách,..."
              value={topicData.ketQuaDuKien}
              onChange={(e) =>
                setTopicData({ ...topicData, ketQuaDuKien: e.target.value })
              }
            />
          </div>
        </div>
      </div>
      <div className="space-y-6">
        {/* Nút hành động */}
        <div className="flex justify-end gap-3 pt-6">
          <button
            className="px-6 py-2 text-gray-700 bg-gray-100 rounded-lg hover:bg-gray-200 dark:bg-gray-600 dark:text-gray-200"
            onClick={() => navigate("/giang-vien-nghien-cuu")}
          >
            Hủy
          </button>
          <button
            className="px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 dark:bg-blue-700 dark:hover:bg-blue-800"
            onClick={handleAddTopic}
          >
            Đăng Ký
          </button>
        </div>
      </div>
    </div>
  );
};

export default NewTopicFormFaculty;
