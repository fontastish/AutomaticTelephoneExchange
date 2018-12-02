using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3AutomaticTelephoneExchange.Company
{
    public class Port
    {
        public PortState State { get; set; }

        public Guid CurrentCallId { get; private set; }

        public event EventHandler<CallEventArgs> CallEvent = (object sender, CallEventArgs e) => { };
        public event EventHandler<AnswerEventArgs> AnswerEvent = (object sender, AnswerEventArgs e) => { };
        public event EventHandler<RejectEventArgs> RejectEvent = (object sender, RejectEventArgs e) => { };

        public event EventHandler<CallEventArgs> IncomingCallEvent = (object sender, CallEventArgs e) => { };

        public Port()
        {
            State = PortState.Connected;
        }

        public void OutgoingCall(object sender, CallEventArgs e)
        {
            if (State == PortState.Connected)
            {
                State = PortState.Call;

                CurrentCallId = Guid.NewGuid();
                e.Id = CurrentCallId;
                Console.WriteLine("Port\t -> OutgoingCall: id {0}", CurrentCallId);
                CallEvent(sender, e);
            }
        }

        public void IncomingCall(int telephoneNumber, int targetTelephoneNumber, Guid id)
        {
            if (State == PortState.Connected)
            {
                State = PortState.Call;

                CurrentCallId = id;
                Console.WriteLine("Port\t -> IncomingCall: id {0}", CurrentCallId);
                IncomingCallEvent(this, new CallEventArgs(telephoneNumber, targetTelephoneNumber));
            }
        }

        public void CallStarted(object sender, AnswerEventArgs e)
        {
            if (State == PortState.Call)
            {
                e.Id = CurrentCallId;
                Console.WriteLine("Port\t -> CallStarted: id {0}", CurrentCallId);
                AnswerEvent(sender, e);
            }
        }

        public void CallStopped(object sender, RejectEventArgs e)
        {
            if (State == PortState.Call)
            {
                e.Id = CurrentCallId;
#if DEBUG
                Console.WriteLine("Port\t -> CallRejecting: id {0}", CurrentCallId);
#endif
                Reset();

                RejectEvent(sender, e);
            }
        }

        public void Reset()
        {
            State = PortState.Connected;
#if DEBUG
            Console.WriteLine("Port\t -> Disconnect");
#endif
            CurrentCallId = Guid.Empty;
        }

        public void Connect(object sender, EventArgs e)
        {
            State = PortState.Connected;
        }

        public void Disconnect(object sender, EventArgs e)
        {
            State = PortState.Disconnected;
        }
    }
}
