using UnityEngine;
using System.Collections;

public interface TimeEvent
{
	//Time remaining until this event is removed from the Queue. -1 will not remove after a set time
	bool TickEvent ();
}

