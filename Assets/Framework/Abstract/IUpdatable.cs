﻿namespace Robot.Framework
{
    public interface IUpdatable
    {
        void OnUpdate();
        void OnFixedUpdate();
        void OnLateUpdate();

    }
}


