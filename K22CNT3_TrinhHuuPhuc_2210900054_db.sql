-- Tạo cơ sở dữ liệu
CREATE DATABASE k22CNT3_TrinhHuuPhuc_Project2;

-- Sử dụng cơ sở dữ liệu vừa tạo
USE k22CNT3_TrinhHuuPhuc_Project2;

-- Tạo bảng QUAN_TRI
CREATE TABLE QUAN_TRI (
    tai_khoan VARCHAR(50) NOT NULL PRIMARY KEY, -- Khóa chính
    mat_khau VARCHAR(255) NOT NULL,
    trang_thai TINYINT
);

-- Tạo bảng VIDEO
CREATE TABLE VIDEO (
    ma_video INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- Khóa chính, tự động tăng
    tieu_de VARCHAR(100),
    mo_ta TEXT,
    duong_dan VARCHAR(255) NOT NULL UNIQUE, -- Đảm bảo duong_dan là duy nhất
    hinh_anh VARCHAR(255),
    the_loai VARCHAR(50) NOT NULL,
    ngay_tao DATETIME NOT NULL,
    ma_quan_tri VARCHAR(50) NOT NULL,
    trang_thai TINYINT,
    FOREIGN KEY (ma_quan_tri) REFERENCES QUAN_TRI(tai_khoan)
);

-- Tạo bảng DANH_MUC_VIDEO
CREATE TABLE DANH_MUC_VIDEO (
    ma_danh_muc INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- Khóa chính, tự động tăng
    ten_danh_muc VARCHAR(100) NOT NULL UNIQUE, -- Đảm bảo ten_danh_muc là duy nhất
    mo_ta TEXT
);

-- Tạo bảng VIDEO_THEO_DANH_MUC
CREATE TABLE VIDEO_THEO_DANH_MUC (
    video_ma_danh_muc INT NOT NULL,
    ma_video INT NOT NULL,
    PRIMARY KEY (ma_video), -- Khóa chính cho bảng này
    FOREIGN KEY (video_ma_danh_muc) REFERENCES DANH_MUC_VIDEO(ma_danh_muc),
    FOREIGN KEY (ma_video) REFERENCES VIDEO(ma_video)
);

-- Tạo bảng BAO_CAO
CREATE TABLE BAO_CAO (
    ma_bao_cao INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- Khóa chính, tự động tăng
    noi_dung TEXT NOT NULL,
    ma_video INT NOT NULL,
    ngay_bao_cao DATETIME NOT NULL,
    ma_quan_tri VARCHAR(50),
    FOREIGN KEY (ma_video) REFERENCES VIDEO(ma_video),
    FOREIGN KEY (ma_quan_tri) REFERENCES QUAN_TRI(tai_khoan)
);
-- Chèn dữ liệu vào bảng QUAN_TRI
INSERT INTO QUAN_TRI (tai_khoan, mat_khau, trang_thai) VALUES 
('admin1', 'password123', 1),
('admin2', 'pass456', 1),
('admin3', 'secure789', 0),
('admin4', 'hashPass101', 1),
('admin5', 'cryptoPass202', 0);
SELECT * FROM QUAN_TRI
-- Chèn dữ liệu vào bảng VIDEO
INSERT INTO VIDEO (tieu_de, mo_ta, duong_dan, hinh_anh, the_loai, ngay_tao, ma_quan_tri, trang_thai) VALUES 
('Video 1', 'Description for Video 1', 'path/to/video1', 'path/to/image1', 'Genre1', '2024-11-01 10:00:00', 'admin1', 1),
('Video 2', 'Description for Video 2', 'path/to/video2', 'path/to/image2', 'Genre2', '2024-11-01 11:00:00', 'admin2', 1),
('Video 3', 'Description for Video 3', 'path/to/video3', 'path/to/image3', 'Genre3', '2024-11-01 12:00:00', 'admin3', 0),
('Video 4', 'Description for Video 4', 'path/to/video4', 'path/to/image4', 'Genre4', '2024-11-01 13:00:00', 'admin4', 1),
('Video 5', 'Description for Video 5', 'path/to/video5', 'path/to/image5', 'Genre5', '2024-11-01 14:00:00', 'admin5', 0);

-- Chèn dữ liệu vào bảng DANH_MUC_VIDEO
INSERT INTO DANH_MUC_VIDEO (ten_danh_muc, mo_ta) VALUES 
('Category 1', 'Description for Category 1'),
('Category 2', 'Description for Category 2'),
('Category 3', 'Description for Category 3'),
('Category 4', 'Description for Category 4'),
('Category 5', 'Description for Category 5');

-- Chèn dữ liệu vào bảng VIDEO_THEO_DANH_MUC
INSERT INTO VIDEO_THEO_DANH_MUC (video_ma_danh_muc, ma_video) VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);

-- Chèn dữ liệu vào bảng BAO_CAO
INSERT INTO BAO_CAO (noi_dung, ma_video, ngay_bao_cao, ma_quan_tri) VALUES 
('Report Content 1', 1, '2024-11-01 15:00:00', 'admin1'),
('Report Content 2', 2, '2024-11-01 16:00:00', 'admin2'),
('Report Content 3', 3, '2024-11-01 17:00:00', 'admin3'),
('Report Content 4', 4, '2024-11-01 18:00:00', 'admin4'),
('Report Content 5', 5, '2024-11-01 19:00:00', 'admin5');

-- Tắt kiểm tra khóa ngoại
ALTER TABLE VIDEO_THEO_DANH_MUC NOCHECK CONSTRAINT ALL;
ALTER TABLE VIDEO NOCHECK CONSTRAINT ALL;
ALTER TABLE BAO_CAO NOCHECK CONSTRAINT ALL;
-- Xóa bảng con trước, sau đó xóa bảng cha
DROP TABLE IF EXISTS VIDEO_THEO_DANH_MUC;
DROP TABLE IF EXISTS BAO_CAO;
DROP TABLE IF EXISTS VIDEO;
DROP TABLE IF EXISTS DANH_MUC_VIDEO;
DROP TABLE IF EXISTS QUAN_TRI;
-- Bật lại kiểm tra khóa ngoại
ALTER TABLE VIDEO_THEO_DANH_MUC CHECK CONSTRAINT ALL;
ALTER TABLE VIDEO CHECK CONSTRAINT ALL;
ALTER TABLE BAO_CAO CHECK CONSTRAINT ALL;

select * from VIDEO
