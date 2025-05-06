namespace UWC.Utilities
{
    public class TagInfo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private int errCode;

        public int ErrCode
        {
            get { return errCode; }
            set { errCode = value; }
        }

        private UHFTAGInfo uhfTagInfo;

        public UHFTAGInfo UhfTagInfo
        {
            get { return uhfTagInfo; }
            set { uhfTagInfo = value; }
        }

    }
}
