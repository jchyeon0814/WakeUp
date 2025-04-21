using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using static wakeUp.Model.YoutubeTimeTable;

namespace wakeUp.Model
{
    public class YoutubeTimeTable
    {
        public enum ExecuteMode
        {
            NONE = 0,
            RECENTLY = 1,
            REALTIME = 2,
            RECORD_RANDOM = 3,
        }

        private int seq;
        private string startTime;
        private string channel;
        private string titleKeyword;
        private ExecuteMode executeMode;

        public YoutubeTimeTable(int seq, string startTime) : this(seq, startTime, null, null, ExecuteMode.NONE)
        {
        }

        public YoutubeTimeTable(int seq, string startTime, string channel, ExecuteMode executeMode) : this(seq, startTime, channel, null, executeMode)
        {
        }

        public YoutubeTimeTable(string startTime, string channel, ExecuteMode executeMode) : this(-1, startTime, channel, null, executeMode)
        {
        }

        public YoutubeTimeTable(string startTime) : this(-1, startTime, null, null, ExecuteMode.NONE)
        {
        }

        public YoutubeTimeTable(string startTime, string channel, string titleKeyword, ExecuteMode executeMode) : this(-1, startTime, channel, titleKeyword, executeMode)
        {
        }

        public YoutubeTimeTable(int seq, string startTime, string channel, string titleKeyword, ExecuteMode executeMode)
        {
            this.seq = seq;
            this.startTime = startTime;
            this.channel = channel;
            this.titleKeyword = titleKeyword;

            if (string.IsNullOrEmpty(channel))
            {
                this.executeMode = ExecuteMode.NONE;
            }
            else
            {
                this.executeMode = executeMode;
            }
        }
        

        public int GetSeq()
        {
            return seq;
        }

        public string GetStartTime() 
        {
            return startTime; 
        }
        public string GetChannel() 
        { 
            return channel; 
        }

        public string GetTitleKeyword()
        {
            return titleKeyword;
        }
        
        public ExecuteMode GetExecuteMode() 
        { 
            return executeMode; 
        }

        public int GetExecuteModeValue()
        {
            return (int) executeMode;
        }

        public void SetStartTime(string startTime)
        {
            this.startTime = startTime;
        }
        public void SetChannel(string channel)
        {
            this.channel = channel;
        }

        public void SetTitleKeyword(string titleKeyword)
        {
            this.titleKeyword = titleKeyword;
        }

        public void SetExecuteMode(ExecuteMode executeMode)
        {
            this.executeMode = executeMode;
        }

        public void SetExecuteModeValue(int executeMode)
        {
            this.executeMode = (ExecuteMode) executeMode;
        }
    }
}
